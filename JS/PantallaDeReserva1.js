const meses = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];
let fechasOcupadas = ["2024-11-15", "2024-11-16", "2024-11-20"];
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

document.addEventListener("DOMContentLoaded", renderizarCalendario);

const bookingForm = document.getElementById("bookingForm");
bookingForm.addEventListener("submit", function (event) {
    event.preventDefault();

    const startDate = document.getElementById("startDate").value;
    const endDate = document.getElementById("endDate").value;

    if (startDate && endDate) {
        agregarReserva(startDate, endDate);
        alert("Reserva realizada con éxito.");
    } else {
        alert("Por favor, selecciona las fechas de entrada y salida.");
    }
});

