import { StartGameModule } from './start-game.module';

describe('StartGameModule', () => {
  let startGameModule: StartGameModule;

  beforeEach(() => {
    startGameModule = new StartGameModule();
  });

  it('should create an instance', () => {
    expect(startGameModule).toBeTruthy();
  });
});
