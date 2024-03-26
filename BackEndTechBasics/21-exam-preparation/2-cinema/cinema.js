'use strict'
function cinema (input)

{
    const numberOfMovies = parseInt(input [0]);
    let movieNames = input.slice(1, numberOfMovies +1);
    const command = input.slice(numberOfMovies +1, input.length);
    console.log(movieNames);
    console.log(command);

}

cinema(['3','Avatar', 'Titanic', 'Joker', 'Sell', 'End', 'Swap 0 1'])