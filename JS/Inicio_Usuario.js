
const mobileQuery = window.matchMedia("(max-width: 768px)");

function handleMobileChange(event) {
    if (event.matches) {

        // Código para dispositivos móviles
        $("#cerrar").on("click", function(){
            $("#mySidebar").css("width", "0px");
            $("#main").css("margin-left", "0px")
        })
        
        $("#abrir").on("click",function(){
            $("#mySidebar").css("width", "100px");
            $("#main").css("margin-left", "100px")
        })
        console.log("Cambiado a vista de móvil");
    } else {
        $("#cerrar").on("click", function(){
            $("#mySidebar").css("width", "0px");
            $("#main").css("margin-left", "0px")
        })
        
        $("#abrir").on("click",function(){
            $("#mySidebar").css("width", "250px");
            $("#main").css("margin-left", "250px")
        })
        // Código para dispositivos más grandes
        console.log("Cambiado a vista de escritorio");
    }
}

mobileQuery.addListener(handleMobileChange); /*Alguien cheque como usar una que no este deprecada, mientras tanto, 
                                             el código hace lo que debería*/

// Llamar a la función al cargar para configurar el estado inicial
handleMobileChange(mobileQuery);
