function circleArea(input) {
    'use strict';
    let argument = typeof (input);
    let area;

    if (argument !== 'number') {
        console.log(`We can not calculate the circle area, because we received a ${argument}.`);
    }
    else {
        area = Math.pow(input, 2) * Math.PI;
        console.log(area.toFixed(2));
    }
}
circleArea(5);