(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("productResource",
                ["$resource",
                 "appSettings",
                 "currentUser",
                    productResource])

    function productResource($resource, appSettings, currentUser) {
        return $resource(appSettings.serverPath + "/api/products/:id",
                null,
                {
                    "get": {
                        headers: { "authorization": "Bearer " + currentUser.getProfile().token }
                    },
                    "save": {
                        headers: { "authorization": "Bearer " + currentUser.getProfile().token }
                    },
                    "update": {
                        method: "PUT",
                        headers: { "authorization": "Bearer " + currentUser.getProfile().token }
                    }
                });
    }
}());

