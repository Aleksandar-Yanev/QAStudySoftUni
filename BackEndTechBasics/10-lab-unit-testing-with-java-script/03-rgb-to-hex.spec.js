import {rgbToHexColor} from "./03-rgb-to-hex.js";
import {expect} from 'chai';

describe('rgbToHexColor', () =>{
    it('Return undefined when the first parameter is invalid type ', () =>{
        //Arrange
        const firstParameterInputString = 'some text';
        const secondParameterIsValid = 122;
        const thirdParameterIsValid = 0;
        //Act
        const result = rgbToHexColor(firstParameterInputString, secondParameterIsValid, thirdParameterIsValid);
        //Assert
        expect(result).to.be.undefined;
    })
    it('Return undefined when the second parameter is out of range - bigger number ', () =>{
        //Arrange
        const firstParameterIsValid = 98;
        const secondParameterIsOutOfRange = 256;
        const thirdParameterIsValid = 0;
        //Act
        const result = rgbToHexColor(firstParameterIsValid, secondParameterIsOutOfRange, thirdParameterIsValid);
        //Assert
        expect(result).to.be.undefined;
    })
    it('Return undefined when the third parameter is out of range - negative number ', () =>{
        //Arrange
        const firstParameterIsValid = 58;
        const secondParameterIsValid = 255;
        const thirdParameterIsOutOfRange = - 40;
        //Act
        const result = rgbToHexColor(firstParameterIsValid, secondParameterIsValid, thirdParameterIsOutOfRange);
        //Assert
        expect(result).to.be.undefined;
    })
    it('Return correct color in hexadecimal format when the parameters is correct', () =>{
        //Arrange
        const firstParameterIsValid = 15;
        const secondParameterIsValid = 243;
        const thirdParameterIsValid = 85;
        //Act
        const result = rgbToHexColor(firstParameterIsValid, secondParameterIsValid, thirdParameterIsValid);
        //Assert
        expect(result).to.be.equal('#0FF355');
    })
    it('Return correct color in hexadecimal format when the parameters is correct', () =>{
        //Arrange
        const firstParameterIsValid = 0;
        const secondParameterIsValid = 0;
        const thirdParameterIsValid = 0;
        //Act
        const result = rgbToHexColor(firstParameterIsValid, secondParameterIsValid, thirdParameterIsValid);
        //Assert
        expect(result).to.be.equal('#000000');
    })
    it('Return correct color in hexadecimal format when the parameters is correct', () =>{
        //Arrange
        const firstParameterIsValid = 255;
        const secondParameterIsValid = 255;
        const thirdParameterIsValid = 255;
        //Act
        const result = rgbToHexColor(firstParameterIsValid, secondParameterIsValid, thirdParameterIsValid);
        //Assert
        expect(result).to.be.equal('#FFFFFF');
    })
})