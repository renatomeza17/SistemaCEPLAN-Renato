let timeout; 
let intervaloRegresivo; 
const tiempoInactividad = 10 * 1000; 



function resetTimer() {
    const modalElement = document.getElementById('modalExpiracion');
    
    // Si el modal está abierto, NO resetear (para dejar que el usuario haga clic)
    if (modalElement && modalElement.classList.contains('show')) {
        return; 
    }

    clearTimeout(timeout);
    clearInterval(intervaloRegresivo);
    timeout = setTimeout(avisarExpiracion, tiempoInactividad);
}

function avisarExpiracion() {
    
    const modalElement = document.getElementById('modalExpiracion');
    const instanciaModal = bootstrap.Modal.getOrCreateInstance(modalElement);
    instanciaModal.show();

    let segundos = 49;
    const spanSegundos = document.getElementById('segundosRestantes');
    spanSegundos.innerText = segundos;

    
    intervaloRegresivo = setInterval(() => {
        segundos--;
        spanSegundos.innerText = segundos;

        if (segundos <= 0) {
            clearInterval(intervaloRegresivo);
            window.location.href = "/Login/Index?mensaje=expirado";
        }
    }, 1000);
}

// BOTÓN EXTENDER (Dentro del Modal)
document.addEventListener("DOMContentLoaded", () => {
    const btnExtender = document.getElementById('btnExtender');
    if (btnExtender) {
        btnExtender.onclick = function() {
            fetch('/Login/RefrescarSesion').then(() => {
               
                const modalElement = document.getElementById('modalExpiracion');
                const instancia = bootstrap.Modal.getOrCreateInstance(modalElement);
                instancia.hide();

               
                clearTimeout(timeout);
                clearInterval(intervaloRegresivo);
                
                
                timeout = setTimeout(avisarExpiracion, tiempoInactividad);
                
                console.log("Sesión reiniciada");
            });
        };
    }
});

document.onmousemove = resetTimer;
document.onkeypress = resetTimer;
resetTimer();