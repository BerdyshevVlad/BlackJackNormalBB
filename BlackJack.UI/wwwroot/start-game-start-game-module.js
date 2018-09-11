(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["start-game-start-game-module"],{

/***/ "./src/app/start-game/start-game-routing.module.ts":
/*!*********************************************************!*\
  !*** ./src/app/start-game/start-game-routing.module.ts ***!
  \*********************************************************/
/*! exports provided: StartGameRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "StartGameRoutingModule", function() { return StartGameRoutingModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _start_start_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./start/start.component */ "./src/app/start-game/start/start.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var routes = [
    {
        path: '',
        component: _start_start_component__WEBPACK_IMPORTED_MODULE_2__["StartComponent"]
    }
];
var StartGameRoutingModule = /** @class */ (function () {
    function StartGameRoutingModule() {
    }
    StartGameRoutingModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"].forChild(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]]
        })
    ], StartGameRoutingModule);
    return StartGameRoutingModule;
}());



/***/ }),

/***/ "./src/app/start-game/start-game.module.ts":
/*!*************************************************!*\
  !*** ./src/app/start-game/start-game.module.ts ***!
  \*************************************************/
/*! exports provided: StartGameModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "StartGameModule", function() { return StartGameModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _start_game_routing_module__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./start-game-routing.module */ "./src/app/start-game/start-game-routing.module.ts");
/* harmony import */ var _start_start_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./start/start.component */ "./src/app/start-game/start/start.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};





var StartGameModule = /** @class */ (function () {
    function StartGameModule() {
    }
    StartGameModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [
                _angular_common__WEBPACK_IMPORTED_MODULE_1__["CommonModule"],
                _start_game_routing_module__WEBPACK_IMPORTED_MODULE_3__["StartGameRoutingModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormsModule"]
            ],
            declarations: [_start_start_component__WEBPACK_IMPORTED_MODULE_4__["StartComponent"]]
        })
    ], StartGameModule);
    return StartGameModule;
}());



/***/ }),

/***/ "./src/app/start-game/start/start.component.css":
/*!******************************************************!*\
  !*** ./src/app/start-game/start/start.component.css ***!
  \******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/start-game/start/start.component.html":
/*!*******************************************************!*\
  !*** ./src/app/start-game/start/start.component.html ***!
  \*******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div *ngIf=\"gameIsRunning==true\">\r\n  <p>\r\n    New Round Is Started\r\n  </p>\r\n</div>\r\n\r\n  <div *ngIf=\"gameIsRunning==false\">\r\n\r\n    <input id=\"inputFieldBotCount\" [(ngModel)]=\"botCount\" type=\"number\" max=\"5\" min=\"1\" />\r\n    <button (click)=\"setBotCount()\">Choose number of players!</button>\r\n    <br />\r\n\r\n  </div>\r\n\r\n\r\n  <div *ngIf=\"gameIsRunning==true\">\r\n\r\n    <ul>\r\n      <li *ngFor=\"let result of playersCards\">\r\n        {{result.player.name}}\r\n        <span *ngFor=\"let card of result.cards\">{{card.value}},</span>\r\n      </li>\r\n    </ul>\r\n\r\n    <br />\r\n\r\n    <h2>TOTAL SCORE</h2>\r\n\r\n    <ul>\r\n      <li *ngFor=\"let result of playersCards\">\r\n        {{result.player.name}}\r\n        <span>{{result.player.score}},</span>\r\n      </li>\r\n    </ul>\r\n    <button [disabled]=\"buttonDisabled\" (click)=\"playAgain()\">MORE</button>\r\n    <button (click)=\"playStay()\">STAY</button>\r\n    <br />\r\n\r\n    <button (click)=\"startNewRound()\">NEW Round</button>\r\n    <button (click)=\"startNewGame()\">NEW Game</button>\r\n\r\n  </div>\r\n\r\n\r\n"

/***/ }),

/***/ "./src/app/start-game/start/start.component.ts":
/*!*****************************************************!*\
  !*** ./src/app/start-game/start/start.component.ts ***!
  \*****************************************************/
/*! exports provided: StartComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "StartComponent", function() { return StartComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/http */ "./node_modules/@angular/http/fesm5/http.js");
/* harmony import */ var _logic_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../logic.service */ "./src/app/logic.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var StartComponent = /** @class */ (function () {
    function StartComponent(_http, _logicService) {
        this._http = _http;
        this._logicService = _logicService;
        this.cards = [];
        this.players = [];
        this.playersCards = [];
        this.roundList = [];
        this.gameList = [];
        this.buttonDisabled = false;
        this.gameIsRunning = false;
    }
    StartComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._http.get("/api/values").subscribe(function (result) {
            _this.cards = result.json();
        });
    };
    StartComponent.prototype.setBotCount = function () {
        var _this = this;
        this.playersCards = null;
        this.buttonDisabled = false;
        if (this.botCount > 0 && this.botCount < 6) {
            var inputField = document.getElementById("inputFieldBotCount");
            inputField.style.background = "green";
        }
        else {
            var inputField = document.getElementById("inputFieldBotCount");
            inputField.style.borderColor = "red";
            return;
        }
        //var ele = document.getElementById("input-player");
        var url = "/api/values/" + this.botCount;
        this._http.get(url).subscribe(function (result) {
            _this.players = result.json();
            _this.gameIsRunning = true;
            _this.handOverCards();
        });
    };
    StartComponent.prototype.handOverCards = function () {
        var _this = this;
        this._http.get("/api/gameLogic").subscribe(function (result) {
            _this.playersCards = result.json();
        });
        return this.playersCards;
    };
    StartComponent.prototype.playAgain = function () {
        var _this = this;
        this._http.get("/api/gamelogic/PlayAgain/true").subscribe(function (result) {
            _this.playersCards = result.json();
        });
    };
    StartComponent.prototype.playStay = function () {
        var _this = this;
        this.buttonDisabled = true;
        this._http.get("/api/gamelogic/PlayAgain/false").subscribe(function (result) {
            _this.playersCards = result.json();
        });
    };
    StartComponent.prototype.startNewRound = function () {
        var _this = this;
        this.buttonDisabled = false;
        this._http.get("/api/gameLogic/StartNewRound").subscribe(function (result) {
            _this.playersCards = result.json();
        });
    };
    StartComponent.prototype.startNewGame = function () {
        this.gameIsRunning = false;
    };
    StartComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-start',
            template: __webpack_require__(/*! ./start.component.html */ "./src/app/start-game/start/start.component.html"),
            styles: [__webpack_require__(/*! ./start.component.css */ "./src/app/start-game/start/start.component.css")]
        }),
        __metadata("design:paramtypes", [_angular_http__WEBPACK_IMPORTED_MODULE_1__["Http"], _logic_service__WEBPACK_IMPORTED_MODULE_2__["LogicService"]])
    ], StartComponent);
    return StartComponent;
}());



/***/ })

}]);
//# sourceMappingURL=start-game-start-game-module.js.map