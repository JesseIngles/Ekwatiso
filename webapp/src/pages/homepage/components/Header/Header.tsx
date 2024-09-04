
import styles from "./Header.module.css";
export default function Header() {
  const {navbar, leftComponents, ancoras, rightComponents} = styles;
  return (
    <>
    <nav className={navbar}>
      <div id={leftComponents}>
        
        
        <div id={ancoras}>
          <a>Home</a>
          <a>Charity</a>
          <a>Disater</a>
          <a>Event</a>
        </div>
      </div>
      <div id={rightComponents}>
        <div>

        </div>
        <div>
          <div></div>
          <h4>(+244) 934 526 466</h4>
        </div>
      </div>
    
    </nav>
    </>
    
  );
};