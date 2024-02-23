/*
function sortingNumbers (arrayOfNumbers) {
    'use strict';

   // let sortedArray = [];
     let sortedArray = arrayOfNumbers.slice().sort((a, b) => a - b);

   // for (let index = 0; index < arrayOfNumbers.length -1; index ++){
    //    sortedArray[index] =
    //}

    arrayOfNumbers.forEach(x => console.log(x));
}

sortingNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);*/

function sortAlternate(arrayOfNumbers) {
    'use strict';

    // Sort the array in ascending order
    let sortedArray = arrayOfNumbers.slice().sort((a, b) => a - b);

    // Initialize the resulting array
    let resultArray = [];

    // Alternate between the smallest and largest elements
    while (sortedArray.length > 0) {
        // Insert the smallest element
        resultArray.push(sortedArray.shift());

        // If there are remaining elements, insert the largest element
        if (sortedArray.length > 0) {
            resultArray.push(sortedArray.pop());
        }
    }

    return resultArray;
}

// Example usage:
let numbers = [1, 65, 3, 52, 48, 63, 31, -3, 18, 56];
let result = sortAlternate(numbers);
console.log(result);
