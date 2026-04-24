const API_ENT = "https://localhost:7113/api/Entregas";
const API_USU = "https://localhost:7113/api/Usuarios";
const API_MAT = "https://localhost:7113/api/Materiales";

document.addEventListener("DOMContentLoaded", () => {
    cargarUsuarios();
    cargarMateriales();
    cargarEntregas();
});

document.getElementById("formEntrega")
    .addEventListener("submit", async function (e) {

        e.preventDefault();

        const data = {
            usuarioId: parseInt(document.getElementById("usuarioId").value),
            materialId: parseInt(document.getElementById("materialId").value),
            pesoKg: parseFloat(document.getElementById("pesoKg").value)
        };

        const r = await fetch(API_ENT, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(data)
        });

        if (r.ok) {
            mostrar("Entrega registrada", "success");
            this.reset();
            cargarEntregas();
        } else {
            mostrar("Error al guardar", "danger");
        }

    });

async function cargarUsuarios() {
    const r = await fetch(API_USU);
    const data = await r.json();

    const combo = document.getElementById("usuarioId");
    combo.innerHTML = "";

    data.forEach(x => {
        combo.innerHTML += `
<option value="${x.id}">
${x.nombre}
</option>`;
    });
}

async function cargarMateriales() {
    const r = await fetch(API_MAT);
    const data = await r.json();

    const combo = document.getElementById("materialId");
    combo.innerHTML = "";

    data.forEach(x => {
        combo.innerHTML += `
<option value="${x.id}">
${x.nombre}
</option>`;
    });
}

async function cargarEntregas() {

    const r = await fetch(API_ENT);
    const data = await r.json();

    const tabla = document.getElementById("tablaEntregas");
    tabla.innerHTML = "";

    data.forEach(x => {
        tabla.innerHTML += `
<tr>
<td>${x.id}</td>
<td>${x.usuarioNombre}</td>
<td>${x.materialNombre}</td>
<td>${x.pesoKg} Kg</td>
<td>${new Date(x.fechaEntrega).toLocaleDateString()}</td>
</tr>`;
    });
}

function mostrar(msg, tipo) {
    document.getElementById("mensaje").innerHTML =
        `<div class="alert alert-${tipo}">${msg}</div>`;
}