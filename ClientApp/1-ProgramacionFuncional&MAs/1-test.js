//https://www.youtube.com/watch?v=JsDiFHT99fM
//Qué es la programación funcional ? inmutabilidad, funciones declarativas sin efectos secundarios

// La forma correcta de leer esto es que a esta apuntando a un espacio de memoria que contiene el 1
// La forma incorrecta de leerlo es decir que a es igual a 1
let a = 1;
let b = 2;

// Cuando se cambia el apuntador, el garbage collector del lenguaje se encarga de limpiar lo anterior

//Modifica variables externas
function funcionSumaIncorrecta(){
    b = 3;
    return a + b;
}

function sumaCorrecta(a, b){
    return a + b;
}

const c = sumaCorrecta(4, 2);

// FUNCIONES DECLARATIVAS (Siempre que se utilizan los mismos parametros, el resultado es el esperado no otro)
// NO CREAR EFECTOS SECUNDARIOS (en la suma incorrecta modificamos variables externas, esto crea ambigüedad dificil de debuguear)
// INMUTABILIDAD === Las cosas se cambian no se modifican!!!

// const significa que la referencia a memoria no se puede cambiar
const persona = {
    nombre: 'Alan',
    lastName: 'Buscaglia'
}

// Esto puede ser costoso para un performance
// const array = [1, 2, 3];
// array.push(4);

// una manera de aplicar inmutabilidad es así
let array = [1, 2, 3];
array = [...array, 4];

// el spreed operator surgio para la inmutabilidad
// es posible usarlo tambien en los objetos

const persona2 = {
    ...persona,
    edad: 29
}

// filtered por ejemplo es una funcion netamente inmutable, programación funcional aplicada
const filteredArray = array.filter(n => n % 2);
console.log(filteredArray);