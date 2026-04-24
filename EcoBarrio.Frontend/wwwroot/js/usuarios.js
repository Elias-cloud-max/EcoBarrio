const API_URL = "https://localhost:7113/api/Usuarios";

document.addEventListener("DOMContentLoaded", cargarUsuarios);

document.getElementById("formUsuario").addEventListener("submit", async function (e) {
    e.preventDefault();

    const usuario = {
        nombre: document.getElementById("nombre").value,
        telefono: document.getElementById("telefono").value,
        direccion: document.getElementById("direccion").value
    };

    try {
        const respuesta = await fetch(API_URL, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(usuario)
        });

        if (respuesta.ok) {
            mostrarMensaje("Usuario registrado correctamente", "success");
            document.getElementById("formUsuario").reset();
            cargarUsuarios();
        } else {
            mostrarMensaje("Error al registrar usuario", "danger");
        }

    } catch (error) {
        mostrarMensaje("No se pudo conectar con la API", "danger");
        console.error(error);
    }
});

async function cargarUsuarios() {
    try {
        const respuesta = await fetch(API_URL);
        const usuarios = await respuesta.json();

        const tabla = document.getElementById("tablaUsuarios");
        tabla.innerHTML = "";

        if (usuarios.length === 0) {
            tabla.innerHTML = `
                <tr>
                    <td colspan="4" class="text-center">No hay usuarios registrados</td>
                </tr>
            `;
            return;
        }

        usuarios.forEach(usuario => {
            tabla.innerHTML += `
                <tr>
                    <td>${usuario.id}</td>
                    <td>${usuario.nombre}</td>
                    <td>${usuario.telefono}</td>
                    <td>${usuario.direccion}</td>
                </tr>
            `;
        });

    } catch (error) {
        document.getElementById("tablaUsuarios").innerHTML = `
            <tr>
                <td colspan="4" class="text-center text-danger">
                    Error al cargar usuarios
                </td>
            </tr>
        `;
        console.error(error);
    }
}

function mostrarMensaje(texto, tipo) {
    document.getElementById("mensaje").innerHTML = `
        <div class="alert alert-${tipo}">
            ${texto}
        </div>
    `;
}