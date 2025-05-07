const estados = [
    { nombre: "verde", duracion: 30000, imagen: "ImagnesSemaforo/Semaforo_verde.png" },
    { nombre: "amarillo", duracion: 3000, imagen: "ImagnesSemaforo/Semaforo_amarillo.png" },
    { nombre: "rojo", duracion: 10000, imagen: "ImagnesSemaforo/Semaforo_rojo.png" }
];

let estadoActual = 0;
let temporizadorId = null;
let contadorIntervalId = null;

function cambiarEstado() {
    const semaforo = document.getElementById("semaforo");
    const temporizador = document.getElementById("temporizador");
    const estado = estados[estadoActual];

    if (semaforo) {
        semaforo.src = estado.imagen;
    }

    // Mostrar tiempo restante en segundos
    let segundosRestantes = estado.duracion / 1000;
    if (temporizador) {
        temporizador.textContent = `${segundosRestantes}`;
    }

    clearInterval(contadorIntervalId); // Limpiar contador previo si lo hay
    contadorIntervalId = setInterval(() => {
        segundosRestantes--;
        if (temporizador) {
            temporizador.textContent = `${segundosRestantes}`;
        }
        if (segundosRestantes <= 0) {
            clearInterval(contadorIntervalId);
        }
    }, 1000);

    estadoActual = (estadoActual + 1) % estados.length;
    temporizadorId = setTimeout(cambiarEstado, estado.duracion);
}

window.iniciarSemaforo = function () {
    if (temporizadorId !== null) {
        clearTimeout(temporizadorId);
        temporizadorId = null;
    }
    if (contadorIntervalId !== null) {
        clearInterval(contadorIntervalId);
        contadorIntervalId = null;
    }

    estadoActual = Math.floor(Math.random() * estados.length)

    const botones = Array.from(document.querySelectorAll('.btn_mv'))
        .filter(boton => !boton.disabled);

    if (estadoActual == 2) {
        botones.forEach(boton => {
            boton.disabled = true;
            console.log(boton)
        });
    } else {
        botones.forEach(boton => {
            boton.disabled = false;
        });
    }
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
