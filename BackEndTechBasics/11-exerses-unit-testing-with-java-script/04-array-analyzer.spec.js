import {analyzeArray} from './04-array-analyzer.js';
import {expect} from "chai";

describe('analyzeArray', () =>{
    it('Should return undefined, when input is not array', () =>{
        //Arrange
        const notArrayInput = 12;
        //Act
        const result = analyzeArray(notArrayInput);
        //Assert
        expect(result).to.be.undefined;
    });
    it('Should return undefined, when input is empty array', () =>{
        //Arrange
        const emptyArrayInput = [];
        //Act
        const result = analyzeArray(emptyArrayInput);
        //Assert
        expect(result).to.be.undefined;
    });
    it('Should return undefined, when input is array with not number', () =>{
        //Arrange
        const notNumberArrayInput = ['3', '5'];
        //Act
        const result = analyzeArray(notNumberArrayInput);
        //Assert
        expect(result).to.be.undefined;
    });
    it('Should return same element, when single element array is given', () => {
        //Arrange
        const singleElementArrayInput = [6];
        //Act
        const result = analyzeArray(singleElementArrayInput);
        //Assert
        expect(result).to.deep.equal({min: 6, max: 6, length: 1});
    });
    it('Should return same element, when same elements array is given', () => {
        //Arrange
        const sameElementArrayInput = [6, 6, 6];
        //Act
        const result = analyzeArray(sameElementArrayInput);
        //Assert
        expect(result).to.deep.equal({min: 6, max: 6, length: 3});
    });
    it('Should return correct result, when mixed elements array is given', () => {
        //Arrange
        const singleElementArrayInput = [6, -8, 15, 3];
        //Act
        const result = analyzeArray(singleElementArrayInput);
        //Assert
        expect(result).to.deep.equal({min: -8, max: 15, length: 4});
    });
});