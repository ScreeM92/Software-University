Parse.Cloud.define("incrementViewCount", function(request, response) {
    Parse.Cloud.useMasterKey();

    var Post = Parse.Object.extend("Post");
    var post = new Post();

    post.id = request.params.postId;
    //var increment = request.params.increment;

    post.increment("visitsCount");
    post.save(null, {
            success: function(post) {
            response.success(true);
            },
            error: function(post, error) {
            response.error("Could not compliment.");
            }
    });
});