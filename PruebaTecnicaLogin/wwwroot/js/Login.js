

document.addEventListener("DOMContentLoaded", function () {
    const loginForm = document.querySelector("form");

    loginForm.addEventListener("submit", function (e) {
        const email = document.querySelector('input[name="correo"]').value;
        const password = document.querySelector('input[name="clave"]').value;

        // Validación simple antes de enviar al servidor
        if (email === "" || password === "") {
            e.preventDefault();
            alert("Por favor, completa todos los campos.");
            return;
        }

        console.log("Intentando iniciar sesión para: " + email);
    });
});