const API = "https://localhost:7113/api/Categorias";

document.addEventListener("DOMContentLoaded", cargarCategorias);

document.getElementById("formCategoria")
    .addEventListener("submit", async function (e) {

        e.preventDefault();

        const data = {
            nombre: document.getElementById("nombre").value,
            descripcion: document.getElementById("descripcion").value
        };

        const r = await fetch(API, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(data)
        });

        if (r.ok) {
            mostrar("Categoría guardada", "success");
            this.reset();
            cargarCategorias();
        } else {
            mostrar("Error al guardar", "danger");
        }

    });

async function cargarCategorias() {

    const r = await fetch(API);
    const data = await r.json();

    const tabla = document.getElementById("tablaCategorias");
    tabla.innerHTML = "";

    data.forEach(x => {
        tabla.innerHTML += `
<tr>
<td>${x.id}</td>
<td>${x.nombre}</td>
<td>${x.descripcion}</td>
</tr>
`;
    });

}

function mostrar(msg, tipo) {
    document.getElementById("mensaje").innerHTML =
        `<div class="alert alert-${tipo}">${msg}</div>`;
}