import { EnumToDescriptionPipe } from './enum-to-description.pipe';

describe('EnumToDescriptionPipe', () => {
  it('create an instance', () => {
    const pipe = new EnumToDescriptionPipe();
    expect(pipe).toBeTruthy();
  });
});
