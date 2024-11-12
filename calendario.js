const estados = {
    libre: "libre",
    pendiente: "pendiente",
    reservado: "reservado"
};


let calendarioEstado = {};

let currentMonth = new Date().getMonth();
let currentYear = new Date().getFullYear();

function cambiarMes(movimiento) {
    currentMonth += movimiento;
    if (currentMonth < 0) {
        currentMonth = 11;
        currentYear--;
    } else if (currentMonth > 11) {
        currentMonth = 0;
        currentYear++;
    }
    mostrarMes();
}

function mostrarMes() {
    const calendar = document.querySelector('.calendar');
    calendar.innerHTML = ''; // Limpiar los días

    const monthYear = document.getElementById('month-year');
    const nombreMes = new Date(currentYear, currentMonth).toLocaleString('es', { month: 'long' });
    monthYear.textContent = `${nombreMes.charAt(0).toUpperCase() + nombreMes.slice(1)} ${currentYear}`;

    const diasMes = new Date(currentYear, currentMonth + 1, 0).getDate();
    const primerDiaMes = new Date(currentYear, currentMonth, 1).getDay();

    for (let i = 0; i < primerDiaMes; i++) {
        const espacioVacio = document.createElement('div');
        calendar.appendChild(espacioVacio);
    }

    for (let dia = 1; dia <= diasMes; dia++) {
        const estadoDia = obtenerEstadoDia(currentYear, currentMonth, dia);
        const diaElemento = document.createElement('button');
        diaElemento.textContent = dia;
        diaElemento.classList.add(estadoDia);
        diaElemento.onclick = () => cambiarEstadoDia(diaElemento, currentYear, currentMonth, dia);
        calendar.appendChild(diaElemento);
    }
}

function obtenerEstadoDia(year, month, day) {
    const key = `${year}-${month + 1}-${day}`;
    return calendarioEstado[key] || estados.libre;
}

function cambiarEstadoDia(elemento, year, month, day) {
    const key = `${year}-${month + 1}-${day}`;
    const estadoActual = calendarioEstado[key] || estados.libre;

    let nuevoEstado;
    if (estadoActual === estados.libre) {
        nuevoEstado = estados.pendiente;
    } else if (estadoActual === estados.pendiente) {
        nuevoEstado = estados.reservado;
    } else {
        nuevoEstado = estados.libre;
    }

    calendarioEstado[key] = nuevoEstado;
    elemento.className = nuevoEstado;

    const estadoFecha = document.getElementById('estadoFecha');
    estadoFecha.textContent = `La fecha ${day} está ahora en estado: ${nuevoEstado}.`;
}

// Inicializar el calendario
mostrarMes();
