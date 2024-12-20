﻿var dominioURL = "https://virtserver.swaggerhub.com/BRIANREYNADZD/Pweb-PIA-QUINTA-EQ/1.0.0";

let fechasOcupadas = [];

function traerFechas() {
    $.ajax({
        url: dominioURL + "/reservaciones",
        type: 'GET',
        dataType: 'json',
        crossDomain: true,
    }).done(function (result) {
        fechasOcupadas = [];
        $(result).each(function (index) {
            if (this.fecha) {
                fechasOcupadas.push(this.fecha);
            }
        });
        renderizarCalendario(); // Renderiza el calendario con las nuevas fechas
    }).fail(function (xhr, status, error) {
        swal.fire({
            icon: 'error',
            title: 'Error al traer fechas',
            text: 'Tenemos un problema al traer las fechas recientes.',
            footer: 'Favor de intentarlo nuevamente más tarde.',
        });
    });
}

const meses = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];
let fechaActual = new Date();

function renderizarCalendario() {
    const mesAnio = document.getElementById("month-year");
    const calendario = document.querySelector(".calendar");

    const mes = fechaActual.getMonth();
    const anio = fechaActual.getFullYear();
    mesAnio.textContent = `${meses[mes]} ${anio}`;

    const primerDia = new Date(anio, mes, 1).getDay();
    const ultimoDia = new Date(anio, mes + 1, 0).getDate();
    calendario.innerHTML = "";

    for (let i = 0; i < primerDia; i++) {
        const celda = document.createElement("div");
        celda.classList.add("empty");
        calendario.appendChild(celda);
    }

    for (let dia = 1; dia <= ultimoDia; dia++) {
        const celda = document.createElement("div");
        celda.classList.add("day");
        celda.textContent = dia;

        const fecha = `${anio}-${String(mes + 1).padStart(2, '0')}-${String(dia).padStart(2, '0')}`;
        if (fechasOcupadas.includes(fecha)) {
            celda.classList.add("reservado");
        } else {
            celda.classList.add("libre");
        }

        calendario.appendChild(celda);
    }
}

function cambiarMes(direccion) {
    fechaActual.setMonth(fechaActual.getMonth() + direccion);
    renderizarCalendario();
}

function agregarReserva(fechaInicio, fechaFin) {
    const inicio = new Date(fechaInicio);
    const fin = new Date(fechaFin);

    while (inicio <= fin) {
        const fechaFormateada = `${inicio.getFullYear()}-${String(inicio.getMonth() + 1).padStart(2, '0')}-${String(inicio.getDate()).padStart(2, '0')}`;
        if (!fechasOcupadas.includes(fechaFormateada)) {
            fechasOcupadas.push(fechaFormateada);
        }
        inicio.setDate(inicio.getDate() + 1);
    }
    renderizarCalendario();
}

document.addEventListener("DOMContentLoaded", function () {
    traerFechas(); // Llama a traerFechas cuando el DOM esté cargado
});

//const bookingForm = document.getElementById("bookingForm");
//bookingForm.addEventListener("submit", function (event) {
  //  event.preventDefault();

    //const startDate = document.getElementById("startDate").value;
    //const endDate = document.getElementById("endDate").value;

//    if (startDate && endDate) {
  //      agregarReserva(startDate, endDate);
   //     alert("Reserva realizada con éxito.");
   // } else {
   //     alert("Por favor, selecciona las fechas de entrada y salida.");
   // }
//});

function confirmarReserva(event) {
    event.preventDefault(); // Prevenir el envío del formulario inmediatamente

    Swal.fire({
        title: '¿Estás seguro?',
        text: "¿Deseas confirmar esta reservación?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sí, reservar!',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire(
                '¡Reservado!',
                'Tu reservación ha sido confirmada.',
                'success'
            );

            // Enviar el formulario después de la confirmación
            document.getElementById('bookingForm').submit();
        }
    });

    return false; // Prevenir el envío automático
}