 var arrayOfNumbers = [3, 5, 2, 7, 9];
    var arrayOfProgramLang = ['Java', 'Python', 'C#' , 'JavaScript' , 'Ruby' ];
    var arrayOfCities = ['Silicon Valley', 'London', 'Las Vegas', 'Paris', 'Sofia'];
    var arrayOfCars = ['BMW', 'Audi', 'Lada', 'Skoda', 'Opel'];

function soothsayer(work,language,city,car){
    return "You will work "+arrayOfNumbers[Math.floor(Math.random()*arrayOfNumbers.length)]+
        " years on "+arrayOfProgramLang[Math.floor(Math.random()*arrayOfProgramLang.length)]+
        ".\nYou will live in "+arrayOfCities[Math.floor(Math.random()*arrayOfCities.length)]+
        " and drive "+arrayOfCars[Math.floor(Math.random()*arrayOfCars.length)];
}
console.log(soothsayer(arrayOfNumbers, arrayOfProgramLang,arrayOfCities,arrayOfCars));
