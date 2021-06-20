

function Mensaje(titulo,mensaje,tipo) {
    Swal.fire(
        titulo,
        mensaje,
        tipo
    )
}

function MensajeCorto(mensaje,tipo) {
    Swal.fire({
        position: 'center',
        icon: tipo,
        title: mensaje,
        showConfirmButton: false,
        timer: 1500
    })

}