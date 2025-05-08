const estados = [
    { nombre: "verde", duracion: 10000, imagen: "ImagnesSemaforo/Semaforo_verde.png" },
    { nombre: "amarillo", duracion: 2000, imagen: "ImagnesSemaforo/Semaforo_amarillo.png" },
    { nombre: "rojo", duracion: 5000, imagen: "ImagnesSemaforo/Semaforo_rojo.png" }
];

let estadoActual = 0;
let temporizadorId = null;
let contadorIntervalId = null;
let dotnetRef = null;

function cambiarEstado() {
    const semaforo = document.getElementById("semaforo");
    const temporizador = document.getElementById("temporizador");
    const estado = estados[estadoActual];

    if (semaforo) {
        semaforo.src = estado.imagen;
    }

    estadoActual = (estadoActual + 1) % estados.length;

    // Mostrar tiempo restante en segundos
    let segundosRestantes = estado.duracion / 1000;
    if (temporizador) {
        temporizador.textContent = `${segundosRestantes}`;
    }

    clearInterval(contadorIntervalId);
    contadorIntervalId = setInterval(() => {
        segundosRestantes--;
        if (temporizador) {
            temporizador.textContent = `${segundosRestantes}`;
        }
        if (segundosRestantes <= 0) {
            clearInterval(contadorIntervalId);
        }
    }, 1000);

    temporizadorId = setTimeout(cambiarEstado, estado.duracion);

    // Invocar método Blazor si se ha proporcionado dotnetRef
    if (dotnetRef) {
        const habilitar = (estado.nombre !== "rojo"); // solo deshabilitar si está en rojo
        dotnetRef.invokeMethodAsync("ActualizarBotones", habilitar);
    }
}

window.iniciarSemaforo = function (dotnetHelper) {

    if (temporizadorId !== null) {
        clearTimeout(temporizadorId);
        temporizadorId = null;
    }

    if (contadorIntervalId !== null) {
        clearInterval(contadorIntervalId);
        contadorIntervalId = null;
    }

    dotnetRef = dotnetHelper; // Referencia a Blazor

    estadoActual = Math.floor(Math.random() * estados.length);
    cambiarEstado();
};

window.detenerSemaforo = function () {
    if (temporizadorId !== null) {
        clearTimeout(temporizadorId);
        temporizadorId = null;
    }
    if (contadorIntervalId !== null) {
        clearInterval(contadorIntervalId);
        contadorIntervalId = null;
    }
};
