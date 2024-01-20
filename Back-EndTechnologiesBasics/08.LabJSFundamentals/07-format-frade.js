function format(grade) {
    'use strict';

    let description = '';

    if (grade < 3.00) {
        description = 'Fail';
    } else if (grade >= 3.00 && grade < 3.50) {
        description = 'Poor';
    } else if (grade >= 3.50 && grade < 4.50) {
        description = 'Good';
    } else if (grade >= 4.50 && grade < 5.50) {
        description = 'Very good';
    } else if (grade >= 5.50) {
        description = 'Excellent';
    }

    if (grade < 3.00){
        console.log(`${description} (2)`);
    } else {
        console.log(`${description} (${grade.toFixed(2)})`);
    }
}

format(3.33);
format(4.50);
format(2.99);
