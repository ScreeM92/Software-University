Parse.Cloud.define('isAdmin', function(req, response){
Parse.Cloud.useMasterKey();
if(!req.params.id){
    response.error('Id has not been provided');
}

var queryRole = new Parse.Query(Parse.Role);
queryRole.equalTo('name', 'Administrator');

queryRole.first({
    success: function(r){
        var role = r;
        var relation = new Parse.Relation(role, 'users');
        var admins = relation.query();

        admins.equalTo('objectId', req.params.id)
        admins.first({
            success: function(u){
                var user = u;

                if(user){
                    response.success(true);
                }else{
                    response.success(false);
                }
            },
            error: function(){
                response.error('Error on user lookup');
            }
        })
    },
    error: function(){
        response.error('User admin check failed');
    }
});
});