define(['item'], function(Item){
	var Section = function () {
        var id = 0;

        function Section(title) {
            this._id = ++id;
            this._title = title ?  title : '';            
            this._items = [];
        }

        Section.prototype.getId = function(){
            return this._id;
        }

        Section.prototype.getTitle = function(){
            return this._title;
        }

        Section.prototype.changeTitle = function(title){
            this._title = title ?  title : '';
        }

        Section.prototype.getItems = function(){
            return this._items;
        }

        Section.prototype.addItem = function(item){
            isItem(item);
            this._items.push(item);
        }

        Section.prototype.deleteItemById = function(id){
            this._items = this._items.filter(function(item){
                return item.getId() !== id;
            });
        }

        function isItem(item){
            if (!(item instanceof Item)) {
                throw new Error('You can add only item');
            };          
        }

        return Section;
    }();

    return Section;
});