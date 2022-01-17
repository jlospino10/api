const titulos = ["Costillares silvestres con calabacin asado y guisantes variados", "Bandeja parmessiana con seleccion de verduras", "Corona de ensalada mixta Cesar-Silvestre con buñuelos", "Pulpo encurtido con salsa de mar y dulces aderezos", "Copa de camarones asados encurtidos con salsa agridulce", "Costillares silvestres con calabacin asado y guisantes variados", ];
const imagenes = ["assets/img/platillos/menu1@2x.png", "assets/img/platillos/menu2@2x.png", "assets/img/platillos/menu3@2x.png", "assets/img/platillos/menu4@2x.png", "assets/img/platillos/menu5@2x.png", "assets/img/platillos/menu1@2x.png"];
const descripcion = ["Disfruta de nuestra especilidad, costillares ahumados acompañado con calabacin silvestre. Ademas, como acompañamiento guisantes variados con salsa agridulce.", "Para disfrutar en acompañamiento, deleitate con el clasico saber de nuestra lasagna con relleno de pavo acompañado con una cuidadosa seleccion de condimentos y granos como acompañantes.", "Plato recomendado de nuestra casa para aquellos amantes de la ensalada. Saborea lo mejor de la ensalada cesar y silvestre en una sola, acompañado de unos buñuelos con masa 100% artesanal.", "Amante de la comida de mar, este platillo es el idea para ti. Disfruta de nuestro pulpo asado enrollado con salsa de mar. Viene acompañado con dulces aderezos para complementar y brindar un sabor agridulce a tu paladar.", "Amaras estos camarones que tenemos para ti. Asados y bañados en salsa agridulce, este manjar despertara todos tus sentidos.", "Disfruta de nuestra especilidad, costillares ahumados acompañado con calabacin silvestre. Ademas, como acompañamiento guisantes variados con salsa agridulce.", "Disfruta de nuestra especilidad, costillares ahumados acompañado con calabacin silvestre. Ademas, como acompañamiento guisantes variados con salsa agridulce."];
const precios = [12000.00, 15000.00, 21000.00, 16000.00, 9000.00, 12000.00];


function mostrarModal(numeroMenu) {

    var numero = numeroMenu - 1; //las pocisiones de array empiezan desde 0, por ende se resta 1 ya que se empieza a contar desde e 1 de lado del front-end

    Swal.fire({
        title: titulos[numero],
        html: "<h5>" + descripcion[numero] + "<br><br><b>Precio: $" + precios[numero] + "</b></h5>",
        imageUrl: imagenes[numero],
        imageWidth: 400,
        imageHeight: 200,
        imageAlt: 'Custom image',
        
    })

}