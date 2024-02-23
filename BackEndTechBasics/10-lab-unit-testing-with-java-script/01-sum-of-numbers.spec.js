import {sum} from './01-sum-of-numbers.js';
import {expect} from 'chai';

describe('01-sum-of-numbers', () => {
    it('should return 0 if an empty array is given', () => {
        //Arrange
        const inputArray = [];

        //Act
        const result = sum(inputArray);

        //Assert
        expect(result).to.equal(0);
    })
    it('should return element if an single element array is given', () => {
        //Arrange
        const inputArray = [6];

        //Act
        const result = sum(inputArray);

        //Assert
        expect(result).to.equal(6);
    })
    it('should return sum if an array with positive number is given', () => {
        //Arrange
        const inputArray = [6, 8, 12, 0];

        //Act
        const result = sum(inputArray);

        //Assert
        expect(result).to.equal(26);
    })
    it('should return sum if an array with negative number is given', () => {
        //Arrange
        const inputArray = [-6, -8, -12, 0];

        //Act
        const result = sum(inputArray);

        //Assert
        expect(result).to.equal(-26);
    })
    it('should return sum if an array with mixed number is given', () => {
        //Arrange
        const inputArray = [-6, -8, 12, 0];

        //Act
        const result = sum(inputArray);

        //Assert
        expect(result).to.equal(-2);
    })
    it('should return 0 if an array with number is given, who give sum 0', () => {
        //Arrange
        const inputArray = [6, 6, -12];

        //Act
        const result = sum(inputArray);

        //Assert
        expect(result).to.equal(0);
    })
});