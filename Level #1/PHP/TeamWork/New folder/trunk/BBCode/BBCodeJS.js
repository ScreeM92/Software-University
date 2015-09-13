function BBCode(fieldName){
    this.fieldName=document.getElementsByClassName(fieldName)[0];
}
BBCode.prototype.eventListener=function eventListener(event){
    var target=event.target;
    if(target.className=='BBButtons'){
        var leftSelection=this.fieldName.value.substring(0, this.fieldName.selectionStart);
        var coreSelection=this.fieldName.value.substring(this.fieldName.selectionStart, this.fieldName.selectionEnd);
        var rightSelection=this.fieldName.value.substring(this.fieldName.selectionEnd, this.fieldName.value.length);
        this.valueMaker(leftSelection, coreSelection, rightSelection, target);
    }
};
BBCode.prototype.valueMaker=function valueMaker(left, center, right, target){
    this.fieldName.value=left;
    this.fieldName.value+=this.BBMaker(target, 'left');
    this.fieldName.value+=center;
    this.fieldName.value+=this.BBMaker(target, 'right');
    this.fieldName.value+=right;
};
BBCode.prototype.BBMaker=function BBMaker(target, side){
    var middle;
    var leftBB;
    var rightBB;
    if(target.innerHTML=='[URL][/URL]' ||
        target.innerHTML=='[IMG][/IMG]'){
        middle=target.innerHTML.indexOf(']');
        leftBB=target.innerHTML.substring(0, middle) + '=';
        rightBB=target.innerHTML.substring(middle);
    }
    else if(target.innerHTML=='[SIZE][/SIZE]' ||
        target.innerHTML=='[COLOR][/COLOR]'){
        middle=target.innerHTML.indexOf(']');
        leftBB=target.innerHTML.substring(0, middle) + '=]';
        rightBB=target.innerHTML.substring(middle + 1);
    }
    else{
        middle=target.innerHTML.indexOf(']') + 1;
        leftBB=target.innerHTML.substring(0, middle);
        rightBB=target.innerHTML.substring(middle);
    }
    switch(side){
        case 'left':
            return leftBB;
            break;
        case 'right':
            return rightBB;
            break;
    }
};
var BBCodeInstaceEdit=new BBCode('ИМЕ НА КЛАСА НА ТЕКСТАРЕАТА В КОЯТО ПОЛЗВАМЕ ББКОДА');
document.addEventListener('click', function(event){BBCodeInstaceEdit.eventListener(event)}, false);
