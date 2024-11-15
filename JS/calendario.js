// Array de los nombres de los meses y días de la semana
const meses = [
    "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
    "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
];

let fechaActual = new Date();

function renderizarCalendario() {
    const mesAnio = document.getElementById("month-year");
    const calendario = document.querySelector(".calendar");
    
    const mes = fechaActual.getMonth();
    const anio = fechaActual.getFullYear();
    
    // Actualizar encabezado del mes y año
    mesAnio.textContent = `${meses[mes]} ${anio}`;
    
    // Obtener el primer y último día del mes
    const primerDia = new Date(anio, mes, 1).getDay();
    const ultimoDia = new Date(anio, mes + 1, 0).getDate();
    
    // Limpiar el calendario
    calendario.innerHTML = "";
    
    // Llenar los días vacíos antes del primer día del mes
    for (let i = 0; i < primerDia; i++) {
        const celda = document.createElement("div");
        celda.classList.add("empty");
        calendario.appendChild(celda);
    }
    
    // Llenar los días del mes
    for (let dia = 1; dia <= ultimoDia; dia++) {
        const celda = document.createElement("div");
        celda.classList.add("day");
        celda.textContent = dia;

        // Agregar eventos de ejemplo
        celda.addEventListener("click", () => seleccionarFecha(dia));

        calendario.appendChild(celda);
    }
}

// Cambiar de mes
function cambiarMes(direccion) {
    fechaActual.setMonth(fechaActual.getMonth() + direccion);
    renderizarCalendario();
}

// Función para seleccionar fecha
function seleccionarFecha(dia) {
    const estadoFecha = document.getElementById("estadoFecha");
    estadoFecha.textContent = `Fecha seleccionada: ${dia} ${meses[fechaActual.getMonth()]} ${fechaActual.getFullYear()}`;
}

// Inicializar el calendario al cargar la página
document.addEventListener("DOMContentLoaded", renderizarCalendario);
