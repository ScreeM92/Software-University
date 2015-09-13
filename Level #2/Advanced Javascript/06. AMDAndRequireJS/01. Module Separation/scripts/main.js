require.config({
    paths: {
        app: 'app',        
        factory: 'factory',
        container: 'container',
        section: 'section',
        item: 'item'      
    }
});

require(['app'], function (app) {
	app.init();
});