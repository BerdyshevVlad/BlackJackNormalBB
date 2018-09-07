import { GameHistoryModule } from './game-history.module';

describe('GameHistoryModule', () => {
  let gameHistoryModule: GameHistoryModule;

  beforeEach(() => {
    gameHistoryModule = new GameHistoryModule();
  });

  it('should create an instance', () => {
    expect(gameHistoryModule).toBeTruthy();
  });
});
