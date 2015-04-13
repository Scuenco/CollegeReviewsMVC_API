app.controller('HomeController', ['$scope', 'ReviewFactory', function ($scope, ReviewFactory) {

    $scope.isDisplayReviews = false;
    $scope.reviews = ReviewFactory.reviews;
    $scope.eReview = { };
    $scope.isEditing = false;

    $scope.editReview = function (review) { 
           // $scope.eReview.ReviewId = id;
        ReviewFactory.editReview(review).then(function (data) {
            $scope.isEditing = false;
            $scope.eReview = {};
            alert("Review was successfully updated.");

        }, function (data) {
            alert("Review update failed.");
        });
    };

    $scope.deleteReview = function(id) {
        ReviewFactory.deleteReview(id).then(function(){
            alert("Review was deleted successfully.");
        }, function(){
            alert("Delete failed.");
        });
    };
}])