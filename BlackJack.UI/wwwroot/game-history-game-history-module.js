(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["game-history-game-history-module"],{

/***/ "./src/app/game-history/game-history-routing.module.ts":
/*!*************************************************************!*\
  !*** ./src/app/game-history/game-history-routing.module.ts ***!
  \*************************************************************/
/*! exports provided: GameHistoryRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "GameHistoryRoutingModule", function() { return GameHistoryRoutingModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _history_list_history_list_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./history-list/history-list.component */ "./src/app/game-history/history-list/history-list.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var routes = [
    {
        path: '',
        component: _history_list_history_list_component__WEBPACK_IMPORTED_MODULE_2__["HistoryListComponent"]
    }
];
var GameHistoryRoutingModule = /** @class */ (function () {
    function GameHistoryRoutingModule() {
    }
    GameHistoryRoutingModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"].forChild(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]]
        })
    ], GameHistoryRoutingModule);
    return GameHistoryRoutingModule;
}());



/***/ }),

/***/ "./src/app/game-history/game-history.module.ts":
/*!*****************************************************!*\
  !*** ./src/app/game-history/game-history.module.ts ***!
  \*****************************************************/
/*! exports provided: GameHistoryModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "GameHistoryModule", function() { return GameHistoryModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _game_history_routing_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./game-history-routing.module */ "./src/app/game-history/game-history-routing.module.ts");
/* harmony import */ var _history_list_history_list_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./history-list/history-list.component */ "./src/app/game-history/history-list/history-list.component.ts");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _progress_kendo_angular_grid__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @progress/kendo-angular-grid */ "./node_modules/@progress/kendo-angular-grid/dist/es/index.js");
/* harmony import */ var _progress_kendo_angular_dropdowns__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @progress/kendo-angular-dropdowns */ "./node_modules/@progress/kendo-angular-dropdowns/dist/es/index.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







var GameHistoryModule = /** @class */ (function () {
    function GameHistoryModule() {
    }
    GameHistoryModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [
                _angular_common__WEBPACK_IMPORTED_MODULE_1__["CommonModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_4__["FormsModule"],
                _game_history_routing_module__WEBPACK_IMPORTED_MODULE_2__["GameHistoryRoutingModule"],
                _progress_kendo_angular_grid__WEBPACK_IMPORTED_MODULE_5__["GridModule"],
                _progress_kendo_angular_dropdowns__WEBPACK_IMPORTED_MODULE_6__["DropDownsModule"]
            ],
            declarations: [_history_list_history_list_component__WEBPACK_IMPORTED_MODULE_3__["HistoryListComponent"]]
        })
    ], GameHistoryModule);
    return GameHistoryModule;
}());



/***/ }),

/***/ "./src/app/game-history/history-list/history-list.component.css":
/*!**********************************************************************!*\
  !*** ./src/app/game-history/history-list/history-list.component.css ***!
  \**********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/game-history/history-list/history-list.component.html":
/*!***********************************************************************!*\
  !*** ./src/app/game-history/history-list/history-list.component.html ***!
  \***********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<p>\r\n  history-list works! My text!\r\n</p>\r\n<!--<ul *ngFor=\"let game of gameList\">\r\n  <li *ngFor=\"let round of game.roundModelList\">\r\n    {{round.player.name}}\r\n    <span *ngFor=\"let card of round.cards\">{{card.value}},</span>\r\n  </li>\r\n</ul>-->\r\n\r\n<!--<kendo-grid [data]=\"gameList\" [height]=\"410\">\r\n\r\n  <kendo-grid-column field=\"playerId\" title=\"ID\" width=\"40\">\r\n  </kendo-grid-column>\r\n  <kendo-grid-column field=\"player.name\" title=\"Name\" width=\"40\">\r\n  </kendo-grid-column>\r\n\r\n</kendo-grid>-->\r\n\r\n\r\n<kendo-grid [data]=\"round\" [height]=\"410\">\r\n \r\n  <kendo-grid-column field=\"player.name\" title=\"Name\" [width]=\"300\">\r\n</kendo-grid-column>\r\n\r\n    \r\n</kendo-grid>\r\n\r\n\r\n\r\n"

/***/ }),

/***/ "./src/app/game-history/history-list/history-list.component.ts":
/*!*********************************************************************!*\
  !*** ./src/app/game-history/history-list/history-list.component.ts ***!
  \*********************************************************************/
/*! exports provided: HistoryListComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HistoryListComponent", function() { return HistoryListComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _logic_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../logic.service */ "./src/app/logic.service.ts");
/* harmony import */ var _angular_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/http */ "./node_modules/@angular/http/fesm5/http.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var HistoryListComponent = /** @class */ (function () {
    function HistoryListComponent(_http, _logicService) {
        this._http = _http;
        this._logicService = _logicService;
        this.gameList = [];
        this.round = [];
        this.sampleProducts = [
            {
                "ProductID": 1,
                "ProductName": "Chai",
                "SupplierID": 1,
                "CategoryID": 1,
                "QuantityPerUnit": "10 boxes x 20 bags",
                "UnitPrice": 18,
                "UnitsInStock": 39,
                "UnitsOnOrder": 0,
                "ReorderLevel": 10,
                "Discontinued": false,
                "Category": {
                    "CategoryID": 1,
                    "CategoryName": "Beverages",
                    "Description": "Soft drinks, coffees, teas, beers, and ales"
                },
                "FirstOrderedOn": new Date(1996, 8, 20)
            },
            {
                "ProductID": 2,
                "ProductName": "Chang",
                "SupplierID": 1,
                "CategoryID": 1,
                "QuantityPerUnit": "24 - 12 oz bottles",
                "UnitPrice": 19,
                "UnitsInStock": 17,
                "UnitsOnOrder": 40,
                "ReorderLevel": 25,
                "Discontinued": false,
                "Category": {
                    "CategoryID": 1,
                    "CategoryName": "Beverages",
                    "Description": "Soft drinks, coffees, teas, beers, and ales"
                },
                "FirstOrderedOn": new Date(1996, 7, 12)
            },
            {
                "ProductID": 3,
                "ProductName": "Aniseed Syrup",
                "SupplierID": 1,
                "CategoryID": 2,
                "QuantityPerUnit": "12 - 550 ml bottles",
                "UnitPrice": 10,
                "UnitsInStock": 13,
                "UnitsOnOrder": 70,
                "ReorderLevel": 25,
                "Discontinued": false,
                "Category": {
                    "CategoryID": 2,
                    "CategoryName": "Condiments",
                    "Description": "Sweet and savory sauces, relishes, spreads, and seasonings"
                },
                "FirstOrderedOn": new Date(1996, 8, 26)
            }
        ];
    }
    HistoryListComponent.prototype.ngOnInit = function () {
        var _this = this;
        debugger;
        this._http.get("/api/gameLogic/getHistory").subscribe(function (result) {
            _this.round = result.json();
        });
        console.log(this.gameList.length);
    };
    HistoryListComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-history-list',
            template: __webpack_require__(/*! ./history-list.component.html */ "./src/app/game-history/history-list/history-list.component.html"),
            styles: [__webpack_require__(/*! ./history-list.component.css */ "./src/app/game-history/history-list/history-list.component.css")]
        }),
        __metadata("design:paramtypes", [_angular_http__WEBPACK_IMPORTED_MODULE_2__["Http"], _logic_service__WEBPACK_IMPORTED_MODULE_1__["LogicService"]])
    ], HistoryListComponent);
    return HistoryListComponent;
}());



/***/ })

}]);
//# sourceMappingURL=game-history-game-history-module.js.map