import Header from "../Header/Header";
import Style from "../Intro-section/Intro-section.module.css";
import logo from './ini.png';

export default function IntroSection() {
  const { firstsection, centralcomponent, buttonSections } = Style;
  const {firstbutton, secondbutton} = Style;
  return (
    <>
      <div className={firstsection}>
        <Header />
        <div className={centralcomponent}>
          <h1>
            <strong>Happiness</strong> comes from <strong>your action.</strong>
          </h1>
          <h5>
            Be a part of the breakthrough and make someone’s dream come true.
          </h5>
          <section className={buttonSections}>
            <div id={firstbutton} aria-label="Donate Now">
              <h3>Donate Now</h3>
            </div>
            <div id={secondbutton} aria-label="Watch Video">
              <h3>Watch Video</h3>
            </div>
          </section>
        </div>
      </div>
    </>
  );
}
