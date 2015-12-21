﻿using ComputationalGeometry.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputationalGeometry.TrapezoidalMap
{
    public class TrapezoidalMap
    {
        public static Node Root { get; set; }
        static IEnumerable<Vertex> Vertices { get; set; }
        static IEnumerable<HalfEdge> HalfEdges { get; set; }
        static IEnumerable<Face> Faces { get; set; }

        public TrapezoidalMap(List<HalfEdge> listEdges)
        {
            int n = listEdges.Count<HalfEdge>();
            var randomPermutation = new RandomPermutation(n);

            Trapezoid RecBoundary = RectangleBoundary(listEdges);

            Root = new TrapezoidalNode(RecBoundary);

        }

        private static Trapezoid RectangleBoundary(List<HalfEdge> listEdges)
        {
            Vector2 origin = listEdges[0].Origin.Position;
            Vector2 twinOrigin = listEdges[0].Twin.Origin.Position;

            double leftCoordinate = origin.X <= twinOrigin.X ? origin.X : twinOrigin.X;
            double rightCoordinate = origin.X >= twinOrigin.X ? origin.X : twinOrigin.X;
            double topCoordinate = origin.Y >= twinOrigin.Y ? origin.Y : twinOrigin.Y;
            double bottomCoordinate = origin.Y <= twinOrigin.Y ? origin.Y : twinOrigin.Y;

            Trapezoid R = new Trapezoid();
            R.Leftp = new Vertex(leftCoordinate, topCoordinate);
            R.Rightp = new Vertex(rightCoordinate, bottomCoordinate);

            R.Top = new HalfEdge();
            R.Bottom = new HalfEdge();
            HalfEdge twinTop = new HalfEdge();
            HalfEdge twinBottom = new HalfEdge();

            R.Leftp.OutEdge = R.Top;
            R.Rightp.OutEdge = R.Bottom;

            R.Top.Origin = R.Leftp;
            R.Bottom.Origin = R.Rightp;
            twinTop.Origin = new Vertex(rightCoordinate, topCoordinate);
            twinBottom.Origin = new Vertex(leftCoordinate, bottomCoordinate);

            R.Top.Twin = twinTop;
            R.Bottom.Twin = twinBottom;
            twinTop.Twin = R.Top;
            twinBottom.Twin = R.Bottom;
            
            return R;
        }

        static Trapezoid PointLocation(Point p, Node root)
        {
            return new Trapezoid();
        }

    }
}
