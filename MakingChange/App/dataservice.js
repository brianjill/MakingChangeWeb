app.dataservice = (function (breeze, logger) {

    breeze.config.initializeAdapterInstance("modelLibrary", "backingStore", true); // backingStore is the modelLibrary for Angular

    var serviceName = 'breeze/MakingChange'; // route to the (same origin) Web Api controller

    var manager = new breeze.EntityManager(serviceName);  // gets metadata from /breeze/NorthBreeze/Metadata

    return {
        getProjects: getProjects
    };

    /*** implementation details ***/

    //#region main application operations
    function getProjects() {
        var query = breeze.EntityQuery
                .from("Projects")
                .orderBy("Name").take(10);

        return manager.executeQuery(query);
    }

    

    //#endregion


})(breeze, app.logger);