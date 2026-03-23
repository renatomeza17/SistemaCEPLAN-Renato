let timer;
const tiempoLimite = 20 * 60 * 1000; // 20 minutos
const tiempoAviso = 18 * 60 * 1000; // Avisar a los 18 minutos

function iniciarTemporizador() {
    clearTimeout(timer);
    
    // Avisar antes de que expire
    timer = setTimeout(() => {
        if (confirm("Su sesión está por expirar por inactividad. ¿Desea extenderla?")) {
            // Si dice que sí, recargamos para refrescar el servidor
            window.location.reload(); 
        } else {
            window.location.href = "/Login?mensaje=expirado";
        }
    }, tiempoAviso);
}

// Reiniciar el reloj si el usuario mueve el mouse o escribe
document.onmousemove = iniciarTemporizador;
document.onkeypress = iniciarTemporizador;

iniciarTemporizador();