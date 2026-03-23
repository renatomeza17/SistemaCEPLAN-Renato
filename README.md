# 🏢 Sistema de Autenticación y Gestión de Perfiles - CEPLAN

Solución de seguridad y administración de identidades desarrollada para **CEPLAN**. El sistema prioriza la protección de datos, la gestión de sesiones en tiempo real y una interfaz alineada a estándares gubernamentales.

### 🛠️ Tecnologías y Buenas Prácticas
* **Stack:** ASP.NET Core 8.0 MVC, EF Core, SQL Server, JavaScript.
* **Arquitectura:** Separación de Responsabilidades (SoC) y Programación Asíncrona.
* **Seguridad:** Cookies configuradas con HttpOnly y SameSite para mitigar ataques XSS/CSRF.

### 🚀 Funcionalidades Clave
* **🛡️ Seguridad y Acceso:** Protección Anti-Fuerza Bruta con bloqueo automático de cuenta por 15 minutos tras el 5to intento fallido. Redirección automatizada al Login tras validación de cuenta.
* **💾 Persistencia:** Control de estados de usuario mediante Entity Framework y SQL Server.

### ⏳ Gestión de Sesión (UX)
* **Control de Inactividad:** Monitoreo mediante site.js que detecta la falta de interacción tras 20 minutos.
* **Modal de Advertencia:** Alerta institucional con conteo regresivo de 49 segundos.
* **Extensión Asíncrona:** Uso de **Fetch API** para refrescar la sesión sin recargar la página.

### 🎨 Interfaz Institucional
* **Diseño Pixel-Perfect:** Maquetación basada en Figma con Bootstrap 5 y CSS3.
* **Componentes Perennes:** Header y Footer institucionales fijos (**blanco perenne**) para una identidad visual constante.
* **Dashboard:** Panel con Sidebar de navegación y organización de datos por Tabs.

---
**👤 Autor:** Renato Meza - Ingeniería de Sistemas - **UNMSM**
