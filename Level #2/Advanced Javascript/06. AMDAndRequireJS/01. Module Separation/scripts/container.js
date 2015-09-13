define(['section'], function(Section){
    var Container = function () {
        function Container(title) {
            this._title = title ?  title : '';
            this._sections = [];
        }

        Container.prototype.getTitle = function() {
            return this._title;
        }

        Container.prototype.changeTitle = function(title){
            this._title = title ?  title : '';
        }

        Container.prototype.getSections = function(){
            return this._sections;
        }

        Container.prototype.addSection = function(section){
            isSection(section);
            this._sections.push(section);
        }

        Container.prototype.deleteSectionById = function(id){
            this._sections = this._sections.filter(function(section){
                return section.getId() !== id;
            });
        }

        function isSection(section){
            if (!(section instanceof Section)) {
                throw new Error('You can add only section');
            };          
        }

        return Container;
    }();

    return Container;
});