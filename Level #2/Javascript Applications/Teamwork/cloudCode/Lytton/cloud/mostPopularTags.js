Parse.Cloud.define("mostPopularTags", function(request, response) {
  Parse.Cloud.useMasterKey();
  var className = request.params.className;
  var limit = parseInt(request.params.limit);
  var query = new Parse.Query(className);
  var tags = {};
  var sortedTags;
 
  query.each(function(row) {
    var postTags = row.attributes.tags;

    for (var i = 0; i < postTags.length; i++) {
    	if (tags.hasOwnProperty(postTags[i])) {
			tags[postTags[i]]++;
		} else {
			tags[postTags[i]] = 1;
		};
    };
  }).then(function(){
	sortedTags = sortProperties(tags);
  }).then(function() {
    response.success(sortedTags.slice(0, limit));
  });

});

function sortProperties(obj){
    var sortable=[];
    for(var key in obj){
    	if(obj.hasOwnProperty(key)){
    		var newObj = {};
    		newObj[key] = obj[key];
        	sortable.push(newObj);
        }
    }

	sortable.sort(function compare(a,b) {
		if (b[Object.keys(b)[0]] !== a[Object.keys(a)[0]]) {
			return b[Object.keys(b)[0]] - a[Object.keys(a)[0]];
		};		

		if (Object.keys(a)[0] < Object.keys(b)[0]){
			return -1;
		}

		if (Object.keys(a)[0] > Object.keys(b)[0]){
			return 1;
		}	    
		return 0;
	});

    return sortable;
}