function displayProperties() {
    var properties = [];
    for (var prop in document) {
        properties.push(prop);
    }

    properties.sort();

    for (var prop in properties) {
        console.log(properties[prop])
    }
}
displayProperties();