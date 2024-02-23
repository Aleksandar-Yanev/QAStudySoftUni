import {lookupChar} from './02-char-lookup.js';
import {expect} from "chai";

describe('lookupChar', () =>{
    it ('Should return undefined, when first parameter is incorrect type and second parameter is correct type', () =>{
        //Arrange
        const incorrectFirstParameter = 154;
        const correctSecondParameter = 0;
        //Act
        const resultUndefined = lookupChar(incorrectFirstParameter, correctSecondParameter);
        //Assert
        expect(resultUndefined).to.be.undefined;
    });
    it ('Should return undefined, when first parameter is correct type and second parameter is incorrect type - floating point number', () =>{
        //Arrange
        const correctFirstParameter = 'Some string';
        const incorrectFloatingPointSecondParameter = 2.3;
        //Act
        const resultUndefined = lookupChar(correctFirstParameter, incorrectFloatingPointSecondParameter);
        //Assert
        expect(resultUndefined).to.be.undefined;
    });
    it ('Should return undefined, when first parameter is correct type and second parameter is incorrect type - string', () =>{
        //Arrange
        const correctFirstParameter = 'Some string';
        const incorrectStringSecondParameter = '4';
        //Act
        const resultUndefined = lookupChar(correctFirstParameter, incorrectStringSecondParameter);
        //Assert
        expect(resultUndefined).to.be.undefined;
    });
    it ('Should return "Incorrect index", when first parameter is correct type and second parameter is incorrect value - bigger then string length', () =>{
        //Arrange
        const correctFirstParameter = 'Some string';
        const biggerStringLengthSecondParameter = 11;
        //Act
        const resultIncorrectIndex = lookupChar(correctFirstParameter, biggerStringLengthSecondParameter);
        //Assert
        expect(resultIncorrectIndex).to.be.equal('Incorrect index');
    });
    it ('Should return "Incorrect index", when first parameter is correct type and second parameter is incorrect value - negative number', () =>{
        //Arrange
        const correctFirstParameter = 'Some string';
        const negativeSecondParameter = -1;
        //Act
        const resultIncorrectIndex = lookupChar(correctFirstParameter, negativeSecondParameter);
        //Assert
        expect(resultIncorrectIndex).to.be.equal('Incorrect index');
    });
    it ('Should return correct char, when first parameter is correct type and second parameter is correct value', () =>{
        //Arrange
        const correctFirstParameter = 'Some string';
        const correctSecondParameter = 6;
        //Act
        const correctResult = lookupChar(correctFirstParameter, correctSecondParameter);
        //Assert
        expect(correctResult).to.be.equal('t');
    });
});