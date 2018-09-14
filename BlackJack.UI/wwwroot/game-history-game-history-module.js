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
/* harmony import */ var _shared_shared_module__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../shared/shared.module */ "./src/app/shared/shared.module.ts");
/* harmony import */ var _game_history_routing_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./game-history-routing.module */ "./src/app/game-history/game-history-routing.module.ts");
/* harmony import */ var _history_list_history_list_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./history-list/history-list.component */ "./src/app/game-history/history-list/history-list.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};




//import { GridModule } from '@progress/kendo-angular-grid';
//import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
var GameHistoryModule = /** @class */ (function () {
    function GameHistoryModule() {
    }
    GameHistoryModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [
                _game_history_routing_module__WEBPACK_IMPORTED_MODULE_2__["GameHistoryRoutingModule"],
                _shared_shared_module__WEBPACK_IMPORTED_MODULE_1__["SharedModule"]
                //GridModule,
                //DropDownsModule
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

module.exports = "h1 {\r\n  text-align: center;\r\n  margin-top:5%;\r\n}\r\n"

/***/ }),

/***/ "./src/app/game-history/history-list/history-list.component.html":
/*!***********************************************************************!*\
  !*** ./src/app/game-history/history-list/history-list.component.html ***!
  \***********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<kendo-grid [data]=\"gridView\" [height]=\"760\" [pageSize]=\"pageSize\"\r\n            [skip]=\"skip\"\r\n            [pageable]=\"true\"\r\n            (pageChange)=\"pageChange($event)\">\r\n  <kendo-grid-column field=\"player.name\" title=\"Name\" [width]=\"300\">\r\n  </kendo-grid-column>\r\n  <kendo-grid-column field=\"cards\" title=\"Cards\" width=\"120\">\r\n    <ng-template kendoGridCellTemplate let-dataItem>\r\n      <ul>\r\n        <li *ngFor=\"let card of dataItem.cards\">{{card.value}}</li>\r\n      </ul>\r\n    </ng-template>\r\n  </kendo-grid-column>\r\n  <kendo-grid-column field=\"player.score\" title=\"Total\" [width]=\"300\">\r\n  </kendo-grid-column>\r\n  <kendo-grid-column field=\"round\" title=\"Round\" [width]=\"300\">\r\n  </kendo-grid-column>\r\n</kendo-grid>\r\n\r\n"

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
/* harmony import */ var _angular_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/http */ "./node_modules/@angular/http/fesm5/http.js");
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
    function HistoryListComponent(_http) {
        this._http = _http;
        this.pageSize = 10;
        this.skip = 0;
        this.round = [];
    }
    HistoryListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._http.get("/api/gameLogic/getHistory").subscribe(function (result) {
            _this.round = result.json();
            _this.loadItems();
            var header = document.getElementById("header");
            header.innerHTML = "GAME HISTORY";
        });
    };
    HistoryListComponent.prototype.pageChange = function (event) {
        this.skip = event.skip;
        this.loadItems();
    };
    HistoryListComponent.prototype.loadItems = function () {
        this.gridView = {
            data: this.round.slice(this.skip, this.skip + this.pageSize),
            total: this.round.length
        };
    };
    HistoryListComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-history-list',
            template: __webpack_require__(/*! ./history-list.component.html */ "./src/app/game-history/history-list/history-list.component.html"),
            styles: [__webpack_require__(/*! ./history-list.component.css */ "./src/app/game-history/history-list/history-list.component.css")]
        }),
        __metadata("design:paramtypes", [_angular_http__WEBPACK_IMPORTED_MODULE_1__["Http"]])
    ], HistoryListComponent);
    return HistoryListComponent;
}());



/***/ })

}]);
//# sourceMappingURL=game-history-game-history-module.js.map