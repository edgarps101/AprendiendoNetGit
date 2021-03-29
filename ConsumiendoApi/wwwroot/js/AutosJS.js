$(document).ready(function () {
    console.log("Vista autos - Prueba");
    tablaAutos();
});

function peticionAjax(url, json, operacion, callback) {
    $.ajax({
        type: operacion,
        url: url,
        data: json,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            callback(response);
        },
        failure: function (response) {
            callback(response);
        },
        error: function (response) {
            callback(response);
        }
    });
}

//function obtenerAutos() {
//    peticionAjax("https://localhost:44311/api/Autos", "{}", function (response) {
//        console.log(response);
//    });
//}

function tablaAutos() {
    var table = $("#tablaAutos").DataTable({
        "ajax": {
            "url": "https://localhost:44311/api/Autos",
            "type": "GET",
            "datatype": "json",
            "dataSrc": ""
        },
        ordering: false,
        info: false,
        searching: false,
        paging: false,
        responsive: true,
        "columns": [
            { "data": "idAuto" },
            { "data": "marca" },
            { "data": "color" },
            { "data": "modelo" },
            { "data": "precio" },
            { "data": "fechaMovimiento" },
            { "data": "activo", visible: false },
            // {
            //     "data": "idAuto", "render": function (data) {
            //         return "<button type='button' class='btn btn-primary' id='editarAuto' onclick='formActualizarAuto("+ data +")'>Editar</button>";
            //     },
            // },
            {
                "render": function () {
                    return '<button type="button" id="editarAuto" class="editar edit-modal btn btn-warning botonEditar"><span class="fa fa-edit"></span><span class="hidden-xs"> Editar</span></button>';
                }
            },
            {
                "data": "idAuto", "render": function (data) {
                    return "<button type='button' class='btn btn-danger' id='eliminarAuto' onclick='eliminarAuto(" + data + ")'>Eliminar</button>";
                },
            }
            // {
            //     "render": function () {
            //         return '<button type="button" id="ButtonEliminar" class="editar edit-modal btn btn-danger botonEditar"><span class="fa fa-edit"></span><span class="hidden-xs"> Eliminar</span></button>';
            //     }
            // },
        ],
        "language": {
            "emptyTable": "No se encontraron registros"
        }

    }).draw();
}

$("#btnAgregarAuto").click(function () {
    $("#inputId").val("");
    $("#inputMarca").val("");
    $("#inputColor").val("");
    $("#inputModelo").val("");
    $("#inputPrecio").val("");
    $('#chkActivo').prop('checked', false);
    $("#actualizarAuto").attr("hidden", true);
    $("#guardarAuto").attr("hidden", false);
    $("#modalAgregarEditar").modal('show');
});

$("#guardarAuto").click(function () {
    var chk;
    if ($('#chkActivo').is(":checked")) {
        chk = true;
    } else {
        chk = false
    }
    peticionAjax('https://localhost:44311/api/Autos', '{ "marca": "' + $("#inputMarca").val() + '", "color": "' + $("#inputColor").val() + '", "modelo": ' + $("#inputModelo").val() + ', "precio": ' + $("#inputPrecio").val() + ', "activo": ' + chk + ' }', 'POST', function (response) {
        var dataTable = $("#tablaAutos").DataTable().destroy();
        cerrarModal();
        tablaAutos();
        $("#modalAgregarEditar").hide();
    });
});

function cerrarModal() {
    $('.close').click();
    $("#inputId").val("");
    $("#inputMarca").val("");
    $("#inputColor").val("");
    $("#inputModelo").val("");
    $("#inputPrecio").val("");
    $('#chkActivo').prop('checked', false);
}

$("#tablaAutos").on("click", ".editar", function () {
    var data = $("#tablaAutos").DataTable().row($(this).parents("tr")).data();
    $("#guardarAuto").attr("hidden", true);
    $("#actualizarAuto").attr("hidden", false);
    $("#inputId").val(data.idAuto);
    $("#inputMarca").val(data.marca);
    $("#inputColor").val(data.color);
    $("#inputModelo").val(data.modelo);
    $("#inputPrecio").val(data.precio);
    if (data.activo) {
        $('#chkActivo').prop('checked', true);
    } else {
        $('#chkActivo').prop('checked', false);
    }
    $("#modalAgregarEditar").modal('show');
});

$("#actualizarAuto").click(function () {
    var chk;
    if ($('#chkActivo').is(":checked")) {
        chk = true;
    } else {
        chk = false
    }
    peticionAjax('https://localhost:44311/api/Autos', '{ "idAuto": ' + $("#inputId").val() + ', "marca": "' + $("#inputMarca").val() + '", "color": "' + $("#inputColor").val() + '", "modelo": ' + $("#inputModelo").val() + ', "precio": ' + $("#inputPrecio").val() + ', "activo": ' + chk + ' }', 'PUT', function (response) {
        var dataTable = $("#tablaAutos").DataTable().destroy();
        cerrarModal();
        tablaAutos();
        $("#modalAgregarEditar").hide();
    });
});

function eliminarAuto(data) {
    var opcion = confirm("¿Realmente quieres eliminar el registro?");
    if (opcion == true) {
        peticionAjax('https://localhost:44311/api/Autos/' + data, '{}', 'DELETE', function (response) {
            var dataTable = $("#tablaAutos").DataTable().destroy();
            tablaAutos();
        });
    }
}