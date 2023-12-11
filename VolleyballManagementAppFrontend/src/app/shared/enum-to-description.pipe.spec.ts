import { EnumIntToDescriptionPipe } from './enum-to-description.pipe';

describe('EnumToDescriptionPipe', () => {
  it('create an instance', () => {
    const pipe = new EnumIntToDescriptionPipe();
    expect(pipe).toBeTruthy();
  });
});
