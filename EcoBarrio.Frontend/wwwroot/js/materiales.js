const API_MAT = "https://localhost:7113/api/Materiales";
const API_CAT = "https://localhost:7113/api/Categorias";

document.addEventListener("DOMContentLoaded", () => {
    cargarCategorias();
    cargarMateriales();
});

document.getElementById("formMaterial")
    .addEventListener("submit", async function (e) {

        e.preventDefault();

        const data = {
            nombre: document.getElementById("nombre").value,
            descripcion: document.getElementById("descripcion").value,
            categoriaId: parseInt(document.getElementById("categoriaId").value)
        };

        const r = await fetch(API_MAT, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(data)
        });

        if (r.ok) {
            mostrar("Material guardado", "success");
            this.reset();
            cargarMateriales();
        } else {
            mostrar("Error al guardar", "danger");
        }

    });

async function cargarCategorias() {

    const r = await fetch(API_CAT);
    const data = await r.json();

    const combo = document.getElementById("categoriaId");
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

    const tabla = document.getElementById("tablaMateriales");
    tabla.innerHTML = "";

    data.forEach(x => {
        tabla.innerHTML += `
<tr>
<td>${x.id}</td>
<td>${x.nombre}</td>
<td>${x.descripcion}</td>
<td>${x.categoriaNombre}</td>
</tr>`;
    });

}

function mostrar(msg, tipo) {
    document.getElementById("mensaje").innerHTML =
        `<div class="alert alert-${tipo}">${msg}</div>`;
}