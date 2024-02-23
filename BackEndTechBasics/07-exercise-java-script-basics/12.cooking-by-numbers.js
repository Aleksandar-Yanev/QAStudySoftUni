function cooking (inputNumber, operator1, operator2, operator3, operator4, operator5){
    'use strict';

    let number = Number (inputNumber);

    switch (operator1){
        case 'chop':
            number /= 2; 
            break;
        case 'dice':
            number = Math.sqrt(number);
            break;
        case 'spice':
            number += 1;
            break;
        case 'bake':
            number *= 3;
            break;
        case 'fillet':
            number *= 0.8;
    }

    console.log (number);

    switch (operator2){
        case 'chop':
            number /= 2; 
            break;
        case 'dice':
            number = Math.sqrt(number);
            break;
        case 'spice':
            number += 1;
            break;
        case 'bake':
            number *= 3;
            break;
        case 'fillet':
            number *= 0.8;
    }

    console.log (number);

    switch (operator3){
        case 'chop':
            number /= 2; 
            break;
        case 'dice':
            number = Math.sqrt(number);
            break;
        case 'spice':
            number += 1;
            break;
        case 'bake':
            number *= 3;
            break;
        case 'fillet':
            number *= 0.8;
    }

    console.log (number);

    switch (operator4){
        case 'chop':
            number /= 2; 
            break;
        case 'dice':
            number = Math.sqrt(number);
            break;
        case 'spice':
            number += 1;
            break;
        case 'bake':
            number *= 3;
            break;
        case 'fillet':
            number *= 0.8;
    }

    console.log (number);

    switch (operator5){
        case 'chop':
            number /= 2; 
            break;
        case 'dice':
            number = Math.sqrt(number);
            break;
        case 'spice':
            number += 1;
            break;
        case 'bake':
            number *= 3;
            break;
        case 'fillet':
            number *= 0.8;
    }

    console.log (number);
}

//cooking ('32', 'chop', 'chop', 'chop', 'chop', 'chop');
cooking ('9', 'dice', 'spice', 'chop', 'bake', 'fillet');