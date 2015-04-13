//http calls here
app.factory('ReviewFactory', ['$http', '$q', function ($http, $q) {
    var reviews = [];

    var getAllReviews = function () {
        var deferred = $q.defer();
        $http({
            method: 'GET',
            url: '/api/apiReviews',
            contentType: 'application/json'
        }).success(function (data) {
            deferred.resolve(data);
        }).error(function (data) {
            deferred.reject(data);
        });
        return deferred.promise;
    };

    getAllReviews().then(function (data) {
        for (var i = 0; i < data.length; i++) {
            reviews.push(data[i]);
        }
    });

    var editReview = function (review) { 
        var deferred = $q.defer();
        $http({
            method: 'PUT',
            url: '/api/apiReviews/Edit', //+ review.ReviewId, 
            data: review, //put review to the backend
            contentType: 'application/json'
        }).success(function (data) {
            for (var i = 0; i < reviews.length; i++) {
                if (reviews[i].ReviewId == review.ReviewId) {
                    reviews[i].Description = review.Description;
                    reviews[i].Rating = review.Rating;
                    break;
                }
            }
            deferred.resolve(data);
        }).error(function (data) {
            deferred.reject(data);
        });
        return deferred.promise;
    };

    var deleteReview = function (id) {
        var deferred = $q.defer();
        $http({
            method: 'DELETE',
            url: '/api/apiReviews/' + id
        }).success(function (data) {
            for (var i=0; i < reviews.length; i++)
            {
                if(reviews[i].ReviewId == id )
                {
                    reviews.splice(i, 1);
                    break;
                }
            }
            deferred.resolve(data);
        }).error(function (data) {
            deferred.reject(data);
        });
        return deferred.promise;
    };

    
    return {
        reviews: reviews,
        editReview: editReview,
        deleteReview: deleteReview
    }
}]);
