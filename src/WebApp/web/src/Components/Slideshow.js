// import React, { useState, useEffect } from 'react';
// import {
//   div,
//   img,
//   button,
//   span,
//   a,
//   h2,
//   ul,
//   li,
// } from 'tailwindcss/lib/components';

// const Slideshow = ({ images }) => {
//   const [currentSlide, setCurrentSlide] = useState(0);

//   useEffect(() => {
//     const interval = setInterval(() => {
//       setCurrentSlide((currentSlide + 1) % images.length);
//     }, 3000);

//     return () => clearInterval(interval);
//   }, []);

//   return (
//     <div class="flex flex-col w-full h-screen">
//       <h2 class="text-center text-4xl mb-4">Slideshow</h2>
//       <ul class="flex flex-row justify-center">
//         {images.map((image, index) => (
//           <li
//             key={index}
//             class="cursor-pointer"
//             onClick={() => setCurrentSlide(index)}
//           >
//             <img
//               src={image.src}
//               alt={image.alt}
//               class="w-full h-full rounded-xl shadow-md"
//             />
//           </li>
//         ))}
//       </ul>
//       <div class="flex flex-row justify-center mt-4">
//         {images.map((image, index) => (
//           <button
//             key={index}
//             class="px-2 py-1 text-gray-500 hover:text-gray-700"
//           >
//             {index + 1}
//           </button>
//         ))}
//       </div>
//     </div>
//   );
// };

// export default Slideshow;