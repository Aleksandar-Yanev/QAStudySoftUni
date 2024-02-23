function rotation(inputArray, numberOfRotation) {
    'use strict';

   // let sortedArray = [];

    for (let index = 1; index <= numberOfRotation; index++) {
        let firstElement = inputArray.shift();
        inputArray.splice((inputArray.length), 0, firstElement);
    }
    console.log(inputArray.join(' '));
}
rotation([51, 47, 32, 61, 21], 2);