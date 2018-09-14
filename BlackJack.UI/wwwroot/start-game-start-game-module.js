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

module.exports = "li {\r\n  list-style-type: none;\r\n}\r\n\r\ninput {\r\n  width: 20%;\r\n  padding: 12px 20px;\r\n  margin: 8px 0;\r\n  display: inline-block;\r\n  border: 1px solid #ccc;\r\n  border-radius: 4px;\r\n  box-sizing: border-box;\r\n}\r\n\r\n.roundStartedMessage {\r\n  text-align: center;\r\n}\r\n\r\n.newGame:hover, .newRound:hover {\r\n  background-color: #4CAF50;\r\n}\r\n\r\n.moreBtn, .stayBtn {\r\n  margin: 15px;\r\n}\r\n\r\n.col-centered {\r\n  float: none;\r\n  margin:auto;\r\n}\r\n\r\n.newRoundBtn, .newGameBtn {\r\n  margin: 10px;\r\n}\r\n\r\n.errorMessageSetBotCount {\r\n  text-align: center;\r\n  color: red;\r\n}\r\n"

/***/ }),

/***/ "./src/app/start-game/start/start.component.html":
/*!*******************************************************!*\
  !*** ./src/app/start-game/start/start.component.html ***!
  \*******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div>\r\n\r\n  <br />\r\n\r\n  <div class=\"roundStartedMessage\" *ngIf=\"newRoundIsStarted==true\">\r\n    <h3>\r\n      New Round Is Started\r\n    </h3>\r\n  </div>\r\n\r\n  <div class=\"input-group mb-3 col-6 col-centered\" *ngIf=\"gameIsRunning==false\">\r\n    <input [(ngModel)]=\"botCount\" type=\"number\" max=\"5\" min=\"1\" class=\"form-control\" id=\"inputFieldBotCount\" placeholder=\"Enter number of bots from 1 to 5\" aria-label=\"Enter number of bots\" aria-describedby=\"basic-addon2\">\r\n    <button class=\"btn btn-success\" (click)=\"setBotCount()\"><i class=\"fas fa-robot\"></i>&nbsp;Choose number of players!&nbsp;<i class=\"fas fa-robot\"></i></button>\r\n  </div>\r\n\r\n  <div class=\"input-group mb-3 col-6 col-centered\">\r\n    <p id=\"errorMessageSetBotCount\" class=\"errorMessageSetBotCount\"></p>\r\n  </div>\r\n\r\n  <br />\r\n\r\n  <div *ngIf=\"gameIsRunning==true\" class=\"container\">\r\n    <div class=\"row\">\r\n      <div class=\"col-12\">\r\n        <div class=\"text-center\">\r\n          <ul>\r\n            <li *ngFor=\"let result of playersCards\">\r\n              {{result.player.name}}\r\n              <span *ngFor=\"let card of result.cards\">{{card.value}},</span>\r\n            </li>\r\n          </ul>\r\n          <br />\r\n          <h2>TOTAL SCORE</h2>\r\n          <ul>\r\n            <li *ngFor=\"let result of playersCards\">\r\n              {{result.player.name}}\r\n              <span>{{result.player.score}}</span>\r\n            </li>\r\n          </ul>\r\n\r\n          <div id=\"winner\" class=\"winner\">\r\n            <ul>\r\n              <li *ngFor=\"let result of winner\">\r\n                <span *ngIf=\"winner.name=='You'\">Congratulations, </span>\r\n                <h3>{{result.name}}</h3> win the game!\r\n              </li>\r\n            </ul>\r\n          </div>\r\n          <button type=\"button\" class=\"btn btn-success moreBtn\" [disabled]=\"moreButtonDisabled\" (click)=\"playAgain()\">MORE</button>\r\n          <button type=\"button\" class=\"btn btn-success stayBtn\" [disabled]=\"stayButtonDisabled\" (click)=\"playStay()\">STAY</button>\r\n        </div>\r\n      </div>\r\n    </div>\r\n    <br />\r\n\r\n\r\n    <div class=\"container\">\r\n      <div class=\"row\">\r\n        <div class=\"col-12\">\r\n          <div class=\"text-center\">\r\n            <button type=\"button\" class=\"btn btn-primary btn-sm newRoundBtn\" (click)=\"startNewRound()\"><i class=\"fas fa-redo-alt\"></i>&nbsp;NEW Round</button>\r\n            <button type=\"button\" class=\"btn btn-primary btn-sm newGameBtn\" (click)=\"startNewGame()\"><i class=\"fas fa-arrow-circle-right\"></i>&nbsp;NEW Game</button>\r\n          </div>\r\n        </div>\r\n      </div>\r\n    </div>\r\n  </div>\r\n</div>\r\n"

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
    function StartComponent(_http) {
        this._http = _http;
        this.cards = [];
        this.players = [];
        this.playersCards = [];
        this.winner = [];
        this.roundList = [];
        this.gameList = [];
        this.maxWinScore = 21;
        this.userName = "You";
        this.moreButtonDisabled = false;
        this.gameIsRunning = false;
        this.stayButtonDisabled = false;
    }
    StartComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._http.get("/api/GameSet").subscribe(function (result) {
            _this.cards = result.json();
            var header = document.getElementById("header");
            header.innerHTML = "GAME IS STARTED";
        });
    };
    StartComponent.prototype.setBotCount = function () {
        var _this = this;
        this.playersCards = null;
        this.moreButtonDisabled = false;
        if (this.botCount > 0 && this.botCount < 6) {
            var inputField = document.getElementById("inputFieldBotCount");
            inputField.style.background = "green";
            var error = document.getElementById("errorMessageSetBotCount");
            error.innerHTML = "";
        }
        else {
            var inputField = document.getElementById("inputFieldBotCount");
            inputField.style.borderColor = "red";
            var error = document.getElementById("errorMessageSetBotCount");
            error.innerHTML = "<i class='fas fa-times'></i>Please set bots from range from 1 to 5";
            inputField.style.background = "";
            return;
        }
        var url = "/api/GameSet/" + this.botCount;
        this._http.get(url).subscribe(function (result) {
            _this.players = result.json();
            _this.gameIsRunning = true;
            _this.handOverCards();
        });
    };
    StartComponent.prototype.handOverCards = function () {
        var _this = this;
        this.newRoundIsStarted = true;
        this._http.get("/api/gameLogic").subscribe(function (result) {
            _this.playersCards = result.json();
        });
        return this.playersCards;
    };
    StartComponent.prototype.playAgain = function () {
        var _this = this;
        this.newRoundIsStarted = false;
        this._http.get("/api/gamelogic/PlayAgain/true").subscribe(function (result) {
            _this.playersCards = result.json();
            for (var i = 0; i < _this.playersCards.length; i++) {
                if (_this.playersCards[i].player.score >= _this.maxWinScore && _this.playersCards[i].player.name == _this.userName) {
                    _this.defineTheWinner();
                    _this.moreButtonDisabled = true;
                    _this.stayButtonDisabled = true;
                }
            }
        });
    };
    StartComponent.prototype.playStay = function () {
        var _this = this;
        this.newRoundIsStarted = false;
        this.moreButtonDisabled = true;
        this.stayButtonDisabled = true;
        this._http.get("/api/gamelogic/PlayAgain/false").subscribe(function (result) {
            _this.playersCards = result.json();
            _this.defineTheWinner();
        });
    };
    StartComponent.prototype.defineTheWinner = function () {
        var _this = this;
        this._http.get("/api/gamelogic/DefineTheWinner").subscribe(function (result) {
            _this.winner = result.json();
        });
    };
    StartComponent.prototype.startNewRound = function () {
        var _this = this;
        this.newRoundIsStarted = true;
        this.moreButtonDisabled = false;
        this.stayButtonDisabled = false;
        this.winner = [];
        this._http.get("/api/gameLogic/StartNewRound").subscribe(function (result) {
            _this.playersCards = result.json();
        });
    };
    StartComponent.prototype.startNewGame = function () {
        this.gameIsRunning = false;
        this.newRoundIsStarted = false;
        this.stayButtonDisabled = false;
        this.winner = [];
    };
    StartComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-start',
            template: __webpack_require__(/*! ./start.component.html */ "./src/app/start-game/start/start.component.html"),
            styles: [__webpack_require__(/*! ./start.component.css */ "./src/app/start-game/start/start.component.css")]
        }),
        __metadata("design:paramtypes", [_angular_http__WEBPACK_IMPORTED_MODULE_1__["Http"]])
    ], StartComponent);
    return StartComponent;
}());



/***/ })

}]);
//# sourceMappingURL=start-game-start-game-module.js.map