function cooking (inputNumber, operator1, operator2, operator3, operator4, operator5){
    'use strict';

    let number = parseInt(inputNumber, 10);

    const operations = [operator1, operator2, operator3, operator4, operator5];

    function executeOperation (currenNumber, currentOperation){
        switch (currentOperation){
            case 'chop':
                return currenNumber / 2; 
                
            case 'dice':
                return Math.sqrt(currenNumber);
                
            case 'spice':
                return currenNumber + 1;
                
            case 'bake':
                return currenNumber * 3;
               
            case 'fillet':
                return currenNumber * 0.8;
        }
    }

    for (const operator of operations){
        number = executeOperation (number, operator);
        console.log (number);
    }
}

//cooking ('32', 'chop', 'chop', 'chop', 'chop', 'chop');
cooking ('9', 'dice', 'spice', 'chop', 'bake', 'fillet');