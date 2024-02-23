import {isSymmetric} from './02-check-for-symmetry.js';
import {expect} from 'chai';

describe('isSymmetric', () => {
    it('return false when incorrect value is given', () => {
        //Arrange
        const inputNumber = 42;
        const inputNull = null;
        const inputString = 'Somthing';
        const inputUndefined = undefined;
        const inputNan = NaN;
        const inputObject = {};
        //Act
        const resultNumber = isSymmetric(inputNumber);
        const resultNull = isSymmetric(inputNull);
        const resultString = isSymmetric(inputString);
        const resultUndefined = isSymmetric(inputUndefined);
        const resultNan = isSymmetric(inputNan);
        const resultObject = isSymmetric(inputObject);
        //Assert
        expect(resultNumber).to.be.false;
        expect(resultNull).to.be.false;
        expect(resultString).to.be.false;
        expect(resultUndefined).to.be.false;
        expect(resultNan).to.be.false;
        expect(resultObject).to.be.false;
    })
    it('return false when non-symmetrical array with even length is given', () => {
        //Arrange
        const inputNonSymmetricalArray = [1, 2, 3, 4];
        //Act
        const resultNonSymmetricalArray = isSymmetric(inputNonSymmetricalArray);
        //Assert
        expect(resultNonSymmetricalArray).to.be.false;
    })
    it('return false when non-symmetrical array with mixed value is given', () => {
        //Arrange
        const inputNonSymmetricalArray = [1, 2, 3, 4, '3', '2', '1'];
        //Act
        const resultNonSymmetricalArray = isSymmetric(inputNonSymmetricalArray);
        //Assert
        expect(resultNonSymmetricalArray).to.be.false;
    })
    it('return false when non-symmetrical array with odd length is given', () => {
        //Arrange
        const inputNonSymmetricalArray = [1, 2, 3, 4, 5];
        //Act
        const resultNonSymmetricalArray = isSymmetric(inputNonSymmetricalArray);
        //Assert
        expect(resultNonSymmetricalArray).to.be.false;
    })
    it('return true when symmetrical array with even length is given', () =>{
        //Arrange
        const inputSymmetricalArray = [1, 2, 3, 4, 4, 3, 2, 1];
        //Act
        const resultSymmetricalArray = isSymmetric(inputSymmetricalArray);
        //AssertS
        expect(resultSymmetricalArray).to.be.true;
    })
    it('return true when symmetrical array with odd length is given', () =>{
        //Arrange
        const inputSymmetricalArray = [1, 2, 3, 4, 3, 2, 1];
        //Act
        const resultSymmetricalArray = isSymmetric(inputSymmetricalArray);
        //AssertS
        expect(resultSymmetricalArray).to.be.true;
    })
    it('return true when symmetrical array with one element is given', () =>{
        //Arrange
        const inputSymmetricalArray = [4];
        //Act
        const resultSymmetricalArray = isSymmetric(inputSymmetricalArray);
        //AssertS
        expect(resultSymmetricalArray).to.be.true;
    })
    it('return true when symmetrical array with one string element is given', () =>{
        //Arrange
        const inputSymmetricalArray = ['bla'];
        //Act
        const resultSymmetricalArray = isSymmetric(inputSymmetricalArray);
        //AssertS
        expect(resultSymmetricalArray).to.be.true;
    })
    it('return true when empty array is given', () =>{
        //Arrange
        const inputEmptyArray = [];
        //Act
        const resultEmptyArray = isSymmetric(inputEmptyArray);
        //AssertS
        expect(resultEmptyArray).to.be.true;
    })
})